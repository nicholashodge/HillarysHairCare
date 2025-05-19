export const getCustomers = async () => {
    const res = await fetch("http://localhost:5001/customers");
    return res.json();
  };

  export const saveNewDog = async (newDog)=> {
  return fetch("/customers",
    {
      method: "POST",
      headers: 
      {
        "Content-Type" : "application/json"
      },
      body: JSON.stringify(newDog)
    }
  ).then(res=>res.json())
}