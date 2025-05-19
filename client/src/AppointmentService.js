export const getAppointmentServices = async () => {
    const res = await fetch("/appointmentServices");
    return res.json();
  };
