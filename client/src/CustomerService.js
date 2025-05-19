export const getCustomers = async () => {
    const res = await fetch("/customers");
    return res.json();
  };
