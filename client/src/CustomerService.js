export const getCustomers = async () => {
    const res = await fetch("http://localhost:5001/customers");
    return res.json();
  };

  export const saveNewCustomer = async (newCustomer)=> {
  return fetch("http://localhost:5001/customers",
    {
      method: "POST",
      headers: 
      {
        "Content-Type" : "application/json"
      },
      body: JSON.stringify(newCustomer)
    }
  ).then(res=>res.json())
}