import { useState, useEffect } from "react"
import { useNavigate } from "react-router-dom"
import { getCustomers, saveNewCustomer } from "./CustomerService.js"


export const AddCustomer = () => {
   const [customer, setCustomer] = useState({})
   const navigate = useNavigate()

   useEffect(()=>{
    getCustomers().then((customerArray)=>{
        setCustomer(customerArray)
    })
   },[])
    
   const handleSave = ()=>{
        
    const newCustomer = 
    {
        name : customer.name,
        
    }
    saveNewCustomer(newCustomer)
    .then(navigate(`/`))
   }
    
    return(
        <div>
            <input 
            className="customerinput"
            type = "text"
            placeholder="Enter name of new customer"
            value = {customer?.name}
            onChange = {(customer)=>{
                const copy = {...customer}
                copy.name = customer?.target.value
                setCustomer(copy)
            }}/>
            <button onClick={handleSave}>Save</button>
        </div>
    )
}