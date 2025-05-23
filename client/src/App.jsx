import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";

import { Outlet } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <>
        <Navbar color="light" expand="md">
          <Nav navbar>
            <NavbarBrand href="/">Hillary's Haircare</NavbarBrand>
            <NavItem>
              <NavLink href="/addCustomer">Add Customer</NavLink>
              <NavLink href="/stylistList">Stylist List</NavLink>
            </NavItem>
          </Nav>
        </Navbar>
        <Outlet />
      </>
    </div>
  );
}

export default App;
