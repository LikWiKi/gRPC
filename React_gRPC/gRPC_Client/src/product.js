import React, {useEffect} from 'react';
import { useState } from 'react';
import { ProductCRUDClient } from "./Protos/ProductCRUD_grpc_web_pb";
import { Empty } from "./Protos/ProductCRUD_pb";
import './App.css';

const userClient = new ProductCRUDClient("https://localhost:5001", null, null);

function Product() {
  //const[products, setProduct] = useState([]);

  const getAllProduct = () =>{
    var empty = new Empty();
    userClient.getAll(empty, null, (err, res) => {
        if (err) {
          console.log(err);
          alert("Login Error.");
          return;
        }
        var model = res.toObject();
        console.log(model);
      });
  }

  useEffect(() => {
    getAllProduct();
  }, [])
  

//   return (
//     <table style="width:100%">
//         <thead>
//             <tr>
//                 <th>
//                     Mã
//                 </th>
//                 <th>
//                     Tên sản phẩm
//                 </th>
//                 <th>
//                     Giá
//                 </th>
//                 <th>
//                     Số lượng
//                 </th>
//                 <th>
//                     Ngày tạo
//                 </th>
//             </tr>
//         </thead>
//         <tbody>
//             {
//                 products.map((item, i) => 
//                 <td>{item.name}</td>)
//             }
//         </tbody>
//     </table>
//   );
}

export default Product;