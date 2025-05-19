export const getCustomers = async () => {
    const res = await fetch("http://localhost:5001/customers");
    return res.json();
  };

 