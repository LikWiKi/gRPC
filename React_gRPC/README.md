# <b>ReactJS with gRPC</b>
## <b>1. SET UP</b>
- Set up VS Code
- Set up NodeJS + NPM
- Set up protoc 3.20.0 + protoc-gen-grpc-web
    - How to setup?
        - Dowload protoc 3.20.0
        - Copy to disk C
        - Add config evironment variables:
           <pre>Start Menu > Edit the system environment variables > Advanced > Environment Variables > Path > New [Add the path of protoc folder]</pre>
        - Check success: open CMD => enter: protoc    

## <b>2. Create WebApp ReactJS</b>
<pre>npm create-react-app grpc-client</pre>
- Install package:
<pre>grpc-web: npm -i grpc-web
google-protobuf: npm -i google-protobuf</pre>

## <b>3. Create protoc file</b>
- Backend had protoc file => use it to genarate code JS to client
- Let genarate code:
<pre>protoc -I=. [INPUT_FOLDER]/*.proto --js_out=import_style=commonjs:[OUTPUT_FOLDER] --grpc-web_out=import_style=commonjs,mode=grpcwebtext:[OUTPUT_FOLDER]</pre>
- Note: 
    - switch <b>powershell</b> to <b>Command Prompt</b> in <b>Terminal</b>
    - [INPUT_FOLDER] is relative path
    - [OUTPUT_FOLDER] is path

## <b>4. Code</b>
- Code call gRPC Server from JS:  
    - <i>Code in product.js file</i>
- Code Server:
    - Add program.cs:
    <pre>
    builder.Services.AddCors();</pre>
    <pre>
    app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
    app.UseCors(options =>
        options.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );</pre>
    - Add nuget: <pre>"Grpc.AspNetCore.Web"</pre>

## <b>5. Run</b>
<pre>Run project backend
Run project frontend: npm start</pre>