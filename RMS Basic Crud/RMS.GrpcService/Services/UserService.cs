using Google.Protobuf;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using RMS.GrpcService.Context;
using RMS.Utility.Models;
using RMS.GrpcService.Protos;
using System.Text;

namespace RMS.GrpcService.Services
{
    public class UserService : PUser.PUserBase
    {
        #region Private Properties
        private readonly AppDbContext _db;
        #endregion

        #region Constructor
        public UserService(AppDbContext db)
        {
            _db = db;
        }
        #endregion

        #region InsertUser
        public override async Task<Reply> InsertUser(UserModel request, ServerCallContext context)
        {
            try
            {
                if (request.UserId == Guid.Empty.ToString())
                {
                    User _user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        Name = request.Name,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        ProfilePic = request.ProfilePic.ToByteArray(),
                        Address = request.Address,
                        CreatedDate = DateTime.UtcNow
                    };

                    _db.Users.Add(_user);
                    _db.SaveChanges();


                    var id = _user.UserId;
                    foreach (var item in request.UserDocs)
                    {
                        UserDoc userDoc = new UserDoc()
                        {
                            UserDocId = Guid.NewGuid(),
                            UserId = id,
                            File = item.File.ToByteArray(),
                            FileName = item.FileName,
                            FileType = item.FileType
                        };

                        _db.UserDocs.Add(userDoc);
                        _db.SaveChanges();
                    }

                    return await Task.FromResult(new Reply
                    {
                        Result = $"Welcome {request.Name}. You're registered successfully.",
                        IsOk = true
                    });
                }
                else
                {
                    var userUp = await _db.Users.Where(i => i.UserId == Guid.Parse(request.UserId)).FirstOrDefaultAsync();

                    if (userUp != null)
                    {
                        if (request.Name != null)
                            userUp.Name = request.Name;
                        else userUp.Name = userUp.Name;

                        if (request.Email != null)
                            userUp.Email = request.Email;
                        else userUp.Email = userUp.Email;

                        if (request.PhoneNumber != null)
                            userUp.PhoneNumber = request.PhoneNumber;
                        else userUp.PhoneNumber = userUp.PhoneNumber;

                        if (request.ProfilePic.Count() != 0)
                            userUp.ProfilePic = request.ProfilePic.ToByteArray();
                        else userUp.ProfilePic = userUp.ProfilePic;

                        if (request.Address != null)
                            userUp.Address = request.Address;
                        else userUp.Address = userUp.Address;

                        userUp.UpdatedDate = DateTime.UtcNow;

                        _db.Users.Update(userUp);
                        _db.SaveChanges();

                        var id = Guid.Parse(request.UserId);

                        if (request.UserDocs.Count() != 0)
                        {
                            var rmDoc = await _db.UserDocs.Where(i => i.UserId == id).ToListAsync();
                            if (rmDoc != null)
                                _db.UserDocs.RemoveRange(rmDoc);
                            _db.SaveChanges();

                            foreach (var item in request.UserDocs)
                            {
                                UserDoc userDoc = new UserDoc()
                                {
                                    UserDocId = Guid.NewGuid(),
                                    UserId = id,
                                    File = item.File.ToByteArray(),
                                    FileName = item.FileName,
                                    FileType = item.FileType
                                };

                                _db.UserDocs.Add(userDoc);
                                _db.SaveChanges();
                            }
                        }

                        return await Task.FromResult(new Reply
                        {
                            Result = $"Hi {request.Name}. You're profile updated successfully.",
                            IsOk = true
                        });
                    }
                    else
                    {
                        return await Task.FromResult(new Reply
                        {
                            Result = $"Error while updating your profile.",
                            IsOk = true
                        });
                    }


                }

            }

            catch (Exception ex)
            {
                return await Task.FromResult(new Reply
                {
                    Result = $"Internal Error. {ex}.",
                    IsOk = false
                });
            }

        }
        #endregion

        #region UpdateUser
        public override async Task<Reply> UpdateUser(UserModel request, ServerCallContext context)
        {
            var ifExists = await _db.Users.Where(i => i.UserId == Guid.Parse(request.UserId)).FirstOrDefaultAsync();

            if (ifExists == null)
                return await Task.FromResult(new Reply()
                {
                    Result = $"Hey! {request.Name} your profile can't be found.",
                    IsOk = false
                });

            try
            {
                ifExists.UserId = Guid.Parse(request.UserId);
                ifExists.Name = request.Name;
                ifExists.Email = request.Email;
                ifExists.PhoneNumber = request.PhoneNumber;
                ifExists.ProfilePic = request.ProfilePic.ToByteArray();
                ifExists.Address = request.Address;
                ifExists.UpdatedDate = DateTime.UtcNow;

                _db.SaveChanges();

                return await Task.FromResult(new Reply
                {
                    Result = $"{request.Name} your profile successfully updated.",
                    IsOk = true
                });
            }

            catch (Exception ex)
            {
                return await Task.FromResult(new Reply
                {
                    Result = $"Internal Error. {ex}.",
                    IsOk = false
                });
            }

        }
        #endregion

        #region DeleteUser
        public override async Task<Reply> DeleteUser(UserLookupModel request, ServerCallContext context)
        {
            var ifExists = await _db.Users.Where(i => i.UserId == Guid.Parse(request.UserId)).FirstOrDefaultAsync();
            var ifExistsDoc = await _db.UserDocs.Where(i => i.UserId == Guid.Parse(request.UserId)).ToListAsync();

            if (ifExists == null)
                return await Task.FromResult(new Reply()
                {
                    Result = $"No record found.",
                    IsOk = false
                });

            try
            {
                if (ifExists != null)
                {
                    _db.Users.Remove(ifExists);
                    _db.SaveChanges();
                }

                if (true)
                {
                    _db.UserDocs.RemoveRange(ifExistsDoc);
                    _db.SaveChanges();
                }

                return await Task.FromResult(new Reply
                {
                    Result = $"Your profile deleted successfully.",
                    IsOk = true
                });
            }

            catch (Exception ex)
            {
                return await Task.FromResult(new Reply
                {
                    Result = $"Internal Error. {ex}.",
                    IsOk = false
                });
            }

        }
        #endregion

        #region GetById
        public override async Task<UserModel> GetUserById(UserLookupModel request, ServerCallContext context)
        {
            // from user.proto
            UserModel objUser = new UserModel();

            var ifExists = await _db.Users.Where(i => i.UserId == Guid.Parse(request.UserId)).FirstOrDefaultAsync();

            if (ifExists != null)
            {
                objUser.UserId = ifExists?.UserId.ToString();
                objUser.Name = ifExists?.Name;
                objUser.Email = ifExists?.Email;
                objUser.PhoneNumber = ifExists?.PhoneNumber;
                objUser.ProfilePic = ByteString.CopyFrom(ifExists?.ProfilePic);
                objUser.Address = ifExists?.Address;
                objUser.CreatedDate = ifExists?.CreatedDate.ToString();
                objUser.UpdatedDate = ifExists?.UpdatedDate.ToString();
                return await Task.FromResult(objUser);
            }
            else
            {
                objUser.Error = new Reply
                {
                    Result = "No record found",
                    IsOk = false
                };
                return await Task.FromResult(objUser);
            }
        }
        #endregion

        #region GetDocById
        public override async Task<UserDocModel> GetUserDocById(UserDocLookupModel request, ServerCallContext context)
        {
            // from user.proto
            UserDocModel objUserDoc = new UserDocModel();

            var ifExists = await _db.UserDocs.Where(i => i.UserDocId == Guid.Parse(request.UserDocId)).FirstOrDefaultAsync();

            if (ifExists != null)
            {
                objUserDoc.UserDocId = ifExists?.UserDocId.ToString();
                objUserDoc.UserId = ifExists?.UserId.ToString();
                objUserDoc.FileName = ifExists?.FileName;
                objUserDoc.FileType = ifExists?.FileType;
                objUserDoc.File = ByteString.CopyFrom(ifExists?.File);
                return await Task.FromResult(objUserDoc);
            }
            else
            {
                objUserDoc.Error = new Reply
                {
                    Result = "No record found",
                    IsOk = false
                };
                return await Task.FromResult(objUserDoc);
            }
        }
        #endregion

        #region GetAllUsers
        public override async Task<UserList> GetAllUsers(Empty request, ServerCallContext context)
        {
            // from user.proto
            UserList objUser = new UserList();

            try
            {
                List<UserModel> userList = new List<UserModel>();

                var _user = _db.Users.ToList();

                if (_user.Count != 0)
                {
                    foreach (var u in _user)
                    {
                        UserModel user = new UserModel()
                        {
                            UserId = u.UserId.ToString(),
                            Name = u.Name,
                            Email = u.Email,
                            PhoneNumber = u.PhoneNumber,
                            ProfilePic = ByteString.CopyFrom(u.ProfilePic),
                            Address = u.Address,
                            CreatedDate = u.CreatedDate.ToString(),
                            UpdatedDate = u.UpdatedDate.ToString()
                        };

                        var _userDoc = _db.UserDocs.Where(x => x.UserId == Guid.Parse(user.UserId)).ToList();

                        foreach (var item in _userDoc)
                        {
                            UserDocModel userDocModel = new UserDocModel()
                            {
                                UserDocId = item.UserDocId.ToString(),
                                UserId = item.UserId.ToString(),
                                FileName = item.FileName,
                                FileType = item.FileType,
                                File = ByteString.CopyFrom(item.File)
                            };

                            user.UserDocs.Add(userDocModel);
                        }

                        userList.Add(user);
                    }

                    objUser.Items.AddRange(userList);
                }
                else
                {
                    objUser.Error = new Reply
                    {
                        Result = "No record found",
                        IsOk = false
                    };
                    return await Task.FromResult(objUser);
                }


            }
            catch (Exception ex)
            {
                objUser.Error = new Reply
                {
                    Result = ex.Message,
                    IsOk = false
                };
                return await Task.FromResult(objUser);
            }
            return await Task.FromResult(objUser);
        }
        #endregion
    }
}
