import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { NavLink } from "react-router-dom"

function CustomerDeleteConfirm() {
  const params = useParams();
  const [customerId, setCustomerID] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [address, setAddress] = useState('');

  useEffect(() => { LoadCustomer(params.id) }, [params.id]);

  const LoadCustomer = async (id) => {
    const url = `${process.env.REACT_APP_BASEURL}/customers/details/${id}`;
    const response = await fetch(url);

    if (!response.ok) {
      console.log('Hittade inga kunder');
    }
    else {
      console.log('Kunderna hittades');
    }

    const customer = await response.json();
    console.log(customer);
    setCustomerID(customer.id);
    setFirstName(customer.firstName);
    setLastName(customer.lastName);
    setEmail(customer.email);
    setPhoneNumber(customer.phoneNumber);
    setAddress(customer.address);
  }

  const onHandleCustomerIdTextChange = (e) => {
    setFirstName(e.target.value)
  }
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

  const onEditClickHandler = async () => {
    console.log(`Tar bort kund med id ${params.id}`);
    const url = `${process.env.REACT_APP_BASEURL}/customers/${params.id}`;
    const response = await fetch(url, {
      method: 'DELETE',
    });

    console.log(response);

    if (response.status >= 200 && response.status <= 299) {
      alert('Kunden togs bort från databasen')
    }
    else {
      alert('VARNING: Kunden togs INTE bort');
    }
  };

  return (
    <>
      <div className="page-section">
        <NavLink to='/customers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Customersidan</h4>
        </NavLink>
        <h2>Bekräfta borttagande av följande kund:</h2>
        <div className="page-content">
          <div className="page-item">
            <form className="form">
              <div className="form-control">
                <input onChange={onHandleCustomerIdTextChange} value={customerId} type="hidden" id='customerId' name='customerId' disabled={true} />
              </div>
              <div className="form-control">
                <label htmlFor="">Förnamn</label>
                <input onChange={onHandleFirstNameTextChange} value={firstName} type="text" id='firstName' name='firstName' disabled={true} />
              </div>
              <div className="form-control">
                <label htmlFor="">Efternamn</label>
                <input onChange={onHandleLastNameTextChange} value={lastName} type="text" id='lastName' name='lastName' disabled={true} />
              </div>
              <div className="form-control">
                <label htmlFor="">Epost</label>
                <input onChange={onHandleEmailTextChange} value={email} type="text" id='email' name='email' disabled={true} />
              </div>
              <div className="form-control">
                <label htmlFor="">Tfnnummer</label>
                <input onChange={onHandlePhoneNumberTextChange} value={phoneNumber} type="text" id='phoneNumber' name='phoneNumber' disabled={true} />
              </div>
              <div className="form-control">
                <label htmlFor="">Adress</label>
                <input onChange={onHandleAddressTextChange} value={address} type="text" id='address' name='address' disabled={true} />
              </div>
              <div className="button">
                <p>Bekräfta borttagning genom att klicka på: <span onClick={onEditClickHandler}>
                  <i className="fa-solid fa-trash-can"></i>
                </span></p>
              </div>
            </form>
          </div>
        </div>
      </div>
    </>
  )
}

export default CustomerDeleteConfirm