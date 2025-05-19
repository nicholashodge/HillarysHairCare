export const getStylists = async () => {
    const res = await fetch("/stylists");
    return res.json();
  };

export const getServices = async () => {
    const res = await fetch("/services");
    return res.json();
  };