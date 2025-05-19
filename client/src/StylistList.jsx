import { getServices, getStylists } from "./StylistService";
import { useEffect, useState } from "react";

export default function StylistList() {
  const [stylists, setStylists] = useState([]);
  const [services, setServices] = useState([]);

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


  return (
    <div>
      {stylists.map((s) => {
        const matchedService = services.find(
          (service) => service.id === s.serviceId
        );
        return (
          <div key={s.id}>
            <div>{s.name}</div>
            <div>{matchedService ? matchedService.name : "Unknown Service"}</div>
            <div>{s.active.toString()}</div>
          </div>
        );
      })}
    </div>
  );
}
