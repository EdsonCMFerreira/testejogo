import React, { useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';

const Index = (props) => {
  
  const [dataAPI,setDataAPI] = useState(props.data);

  const handleSubmit = async () => {
    try {
      
      const response = await axios({
        method: 'post',
        url: '/api/rodada',
        // data: "",
        // headers: {
        // 'Content-Type': 'application/json;charset=UTF-8'

        // }
        
      });
      console.log(response);
    } catch (error) {
      console.log(error);
    }

    


  };
  return (
    <>
      <h1>Lista Geral com os resultados de todos as apostas</h1>
      <ul>
        {dataAPI.map((item)=> (
            <li key={item.id}>
              <h3>{item.dado}</h3>
              <p>{item.creactedAt}</p>
              <p>{item.mensagem}</p>
            </li>
          ))}
      </ul>
      <button onClick={()=>handleSubmit()}> Rolar dados </button>
    </>
  )
}
Index.getInitialProps = 
  async function() {
    const res = await axios.get('http://localhost:3000/api/rodada')
    const data = await res.data
  return {
    data: data
  }
}

export default Index