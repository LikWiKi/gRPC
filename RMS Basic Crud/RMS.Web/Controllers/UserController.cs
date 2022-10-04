using Google.Protobuf;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using RMS.Utility.Models.ViewModels;
using RMS.Web.Protos;
using RMS.Web.Utility;

namespace RMS.Web.Controllers
{
    public class UserController : Controller
    {
        #region Private Properties

        private readonly ILogger<HomeController> _logger;

        ServerChannel schannel = new ServerChannel();
        #endregion

        #region Constructor
        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region InsertUser
        [HttpGet]
        public async Task<IActionResult> Index(string msg, string Status, Guid uId)
        {
            UserVM userVM = new UserVM();
            if (msg != null)
            {
                if (msg == "Success")
                {
                    ViewBag.success = Status;
                }
                if (msg == "Update")
                {
                    ViewBag.update = Status;
                }
                if (msg == "Delete")
                {
                    ViewBag.delete = Status;
                }
                if (msg == "Invailde")
                {
                    ViewBag.failed = Status;
                }
            }

            if (uId != Guid.Empty)
            {
                using (GrpcChannel grpc = schannel.Initial())
                {
                    var findUserById = new PUser.PUserClient(grpc);
                    var input = new UserLookupModel { UserId = uId.ToString() };
                    var user = await findUserById.GetUserByIdAsync(input);
                    userVM.UserId = Guid.Parse(user.UserId);
                    userVM.Name = user.Name;
                    userVM.Email = user.Email;
                    userVM.Address = user.Address;
                    userVM.PhoneNumber = user.PhoneNumber;
                }
            }
            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserVM userVM)
        {
            try
            {
                // Proto Model
                UserModel userModel = new UserModel()
                {
                    UserId = userVM.UserId.ToString(),
                    Name = userVM.Name,
                    Email = userVM.Email,
                    PhoneNumber = userVM.PhoneNumber,
                    Address = userVM.Address
                };

                if (userVM.ProfilePic != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await userVM.ProfilePic.CopyToAsync(stream);
                        userModel.ProfilePic = ByteString.CopyFrom(stream.ToArray());
                    }
                }

                if (userVM.File != null)
                {
                    foreach (var item in userVM.File)
                    {
                        UserDocModel userDocModel = new UserDocModel()
                        {
                            FileName = item.FileName,
                            FileType = item.ContentType
                        };

                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            userDocModel.File = ByteString.CopyFrom(stream.ToArray());
                        }

                        userModel.UserDocs.Add(userDocModel);

                    }

                }

                string? Status;

                using (GrpcChannel grpc = schannel.Initial())
                {
                    var addUser = new PUser.PUserClient(grpc);
                    var reply = await addUser.InsertUserAsync(userModel);
                    Status = reply.Result;
                }

                if (userVM.UserId == Guid.Empty)
                    return RedirectToAction("Index", "User", new { msg = "Success", Status = Status });
                else
                    return RedirectToAction("List", "User", new { msg = "Update", Status = Status });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "User", new { msg = "Invailde", Status = ex.Message });
            }
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> List(string msg, string Status)
        {
            if (msg != null)
            {
                if (msg == "Success")
                {
                    ViewBag.success = Status;
                }
                if (msg == "Update")
                {
                    ViewBag.update = Status;
                }
                if (msg == "Delete")
                {
                    ViewBag.delete = Status;
                }
                if (msg == "Invailde")
                {
                    ViewBag.failed = Status;
                }
            }
            try
            {
                using (GrpcChannel grpc = schannel.Initial())
                {
                    var allUser = new PUser.PUserClient(grpc);
                    var empty = new Empty();
                    var userList = await allUser.GetAllUsersAsync(empty);
                    ViewBag.userLists = userList;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View(msg = "Invailde", Status = ex.Message);
            }
        }

        #region GetDocById
        [HttpGet]
        public async Task<FileResult> GetDocumentById(Guid id)
        {
            using (GrpcChannel grpc = schannel.Initial())
            {
                var findUserDocById = new PUser.PUserClient(grpc);
                var input = new UserDocLookupModel { UserDocId = id.ToString() };
                var userDoc = await findUserDocById.GetUserDocByIdAsync(input);
                return File(userDoc.File.ToByteArray(), userDoc.FileType, userDoc.FileName);
            }
        }
        #endregion

        #region DeleteUser
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                string? Status;
                using (GrpcChannel grpc = schannel.Initial())
                {
                    var DeleteById = new PUser.PUserClient(grpc);
                    var input = new UserLookupModel { UserId = id.ToString() };
                    var reply = await DeleteById.DeleteUserAsync(input);
                    Status = reply.Result;
                }
                return RedirectToAction("List", "User", new { msg = "Delete", Status = Status });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "User", new { msg = "Invailde", Status = ex.Message });
            }

        }
        #endregion

        #region GetUserById
        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            using (GrpcChannel grpc = schannel.Initial())
            {
                var findUserById = new PUser.PUserClient(grpc);
                var input = new UserLookupModel { UserId = id.ToString() };
                var user = await findUserById.GetUserByIdAsync(input);
                ViewBag.users = user;
                return Json(new
                {
                    Data = user
                });

            }
        }
        #endregion
    }
}
