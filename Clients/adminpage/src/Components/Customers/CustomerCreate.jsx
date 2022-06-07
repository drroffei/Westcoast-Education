import { NavLink } from "react-router-dom"
import { useState } from "react"

function Create() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [address, setAddress] = useState('');



  const onHandleFirstNameTextChange = (e) => {
    setFirstName(e.target.value)
  }
  const onHandleLastNameTextChange = (e) => {
    setLastName(e.target.value)
  }
  const onHandleEmailTextChange = (e) => {
    setEmail(e.target.value)
  }
  const onHandlePhoneNumberTextChange = (e) => {
    setPhoneNumber(e.target.value)
  }
  const onHandleAddressTextChange = (e) => {
    setAddress(e.target.value)
  }

  const handleSaveCustomer = (e) => {
    e.preventDefault();
    const customer = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      phoneNumber: phoneNumber,
      address: address
    }
    saveCustomer(customer)
    console.log(customer)
  }

  const saveCustomer = async (customer) => {
    const url = `${process.env.REACT_APP_BASEURL}/customers`
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(customer),
    });

    if (response.status >= 200 && response.status <= 299) {
      console.log(await response.json())
      alert('Kunden sparades korrekt!')
    }
    else {
      console.log(await response.json())
      alert('VARNING: Kunden sparades INTE korrekt!')
    }
  }

  return (
    <>
      <div className="page-section">
        <NavLink to='/customers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Customersidan</h4>
        </NavLink>
        <h2 className="page-title">Registrera en ny kund i databasen</h2>
        <div className="page-content">
          <form className="form" onSubmit={handleSaveCustomer}>
            <div className="form-control">
              <label htmlFor="">Förnamn</label>
              <input onChange={onHandleFirstNameTextChange} value={firstName} type="text" id='firstName' name='firstName' />
            </div>
            <div className="form-control">
              <label htmlFor="">Efternamn</label>
              <input onChange={onHandleLastNameTextChange} value={lastName} type="text" id='lastName' name='lastName' />
            </div>
            <div className="form-control">
              <label htmlFor="">Epost</label>
              <input onChange={onHandleEmailTextChange} value={email} type="text" id='email' name='email' />
            </div>
            <div className="form-control">
              <label htmlFor="">Tfnnummer</label>
              <input onChange={onHandlePhoneNumberTextChange} value={phoneNumber} type="text" id='phoneNumber' name='phoneNumber' />
            </div>
            <div className="form-control">
              <label htmlFor="">Adress</label>
              <input onChange={onHandleAddressTextChange} value={address} type="text" id='address' name='address' />
            </div>
            <div className="button">
              <button type="submit" className="btn">Spara</button>
            </div>
          </form>
        </div>
      </div>
    </>
  )
}
export default Create