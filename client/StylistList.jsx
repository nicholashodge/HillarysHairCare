import { getServices, getStylists } from "./StylistService";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getStylists } from "./StylistService";

export default function Home() {
  const [stylists, setStylists] = useState([])
  const [services, setServices ] = useState([])



  useEffect(() => {
    getStylists()
      .then(setStylists)
      .catch(() => {
        console.log("API not connected");
      });
  }, []);

    useEffect(() => {
    getServices()
      .then(setServices)
      .catch(() => {
        console.log("API not connected");
      });
  }, []);




const matchedService = services.find(service => service.id === s.serviceId);
  return (
<div> 
    <div key={s.id}>
    <div>{s.name}</div>
    <div>{matchedService.name}</div>    
    <div> {s.serviceId} </div>
    <div> {s.active} </div>
    
    </div>
  
</div>
  )
  }
  