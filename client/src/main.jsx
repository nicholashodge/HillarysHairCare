import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import StylistList from "./StylistList";
import { AddCustomer } from "./AddCustomer";
import AppointmentList from "./AppointmentList";


const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route index element={<StylistList />} />
        <Route path="/addCustomer" element={<AddCustomer/>}/>
        <Route path="/stylistList" element={<AppointmentList/>}/>
      </Route>
    </Routes>
  </BrowserRouter>,
);
