import { getServices } from "./StylistService.js";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getStylists } from "./StylistService.js";
import { getAppointments } from "./AppointmentService.js";
import { getCustomers } from "./CustomerService.js";
import { getAppointmentServices } from "./AppointmentService.js";

export default function AppointmentList() {
  const [stylists, setStylists] = useState([]);
  const [appointments, setAppointments] = useState([]);
  const [services, setServices] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [appointmentServices, setAppointmentServices] = useState([]);

  useEffect(() => {
    getAppointments()
      .then(setAppointments)
      .catch(() => {
        console.log("API not connected");
      });
  }, []);

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

  useEffect(() => {
    getCustomers()
      .then(setCustomers)
      .catch(() => {
        console.log("API not connected");
      });
  }, []);

  useEffect(() => {
    getAppointmentServices()
      .then(setAppointmentServices)
      .catch(() => {
        console.log("Api not connected")
      })
  }, [])





  return (
    <div>
      {appointments.map(a => {
        const appointmentServiceItems = appointmentServices.filter(
          as => as.appointmentId === a.id
        );
        const customer = customers.find(c => c.id === a.customerId);
        const stylist = stylists.find(s => s.id === a.stylistId);


        return (
          <div key={a.id}>
            <div>Appointment Time: {a.appointmentTime}</div>
            <div>Customer: {customer ? customer.name : "Unknown Customer"}</div>
            <div>Stylist: {stylist ? stylist.name : "Unknown Stylist"}</div>
            <div> Total Cost: {a.totalCost}</div>


            {appointmentServiceItems.map(asi => {
              const matchedService = services.find(service => service.id === asi.serviceId);
              return (
                <div key={asi.id}>
                  {matchedService ? matchedService.name : "Unknown Service"}
                </div>
               
              );
            })}
          </div>
        );
      })}
    </div>
  );
}