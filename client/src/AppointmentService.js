export const getAppointmentServices = async () => {
    const res = await fetch("http://localhost:5001/appointmentServices");
    return res.json();
  };
