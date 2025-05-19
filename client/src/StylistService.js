export const getStylists = async () => {
    const res = await fetch("http://localhost:5001/stylists");
    return res.json();
  };

export const getServices = async () => {
    const res = await fetch("http://localhost:5001/services");
    return res.json();
  };