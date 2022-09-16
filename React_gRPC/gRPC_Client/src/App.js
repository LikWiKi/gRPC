import logo from './logo.svg';
import { ProductCRUDClient } from "./Protos/ProductCRUD_grpc_web_pb";
import { ProductRequest } from "./Protos/ProductCRUD_pb";
import './App.css';

const userClient = new ProductCRUDClient("https://localhost:5001", null, null);

function App() {
  const getAll = () =>{
    var empty = new Product.ProductCRUD.Empty;
    var test = userClient.getAll(empty);
    console.log(test);
  }
  return (
    <div className="App">
      <button onClick={getAll}>Load</button>
    </div>
  );
}

export default App;
