import { NavLink } from "react-router-dom"
import { useState } from "react"

function CreateTeacher() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [address, setAddress] = useState('');
  const [skill, setSkill] = useState('');

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
  const onHandleSkillTextChange = (e) => {
    setSkill(e.target.value)
  }
  
  const handleSaveTeacher = (e) => {
    e.preventDefault();
    const teacher = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      phoneNumber: phoneNumber,
      address: address,
      teacherSkill: skill
    }
    console.log(teacher)
    saveTeacher(teacher)
  }

  const saveTeacher = async (teacher) => {
    const url = `${process.env.REACT_APP_BASEURL}/teachers`
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(teacher),
    });

    if (response.status >= 200 && response.status <= 299) {
      console.log(await response.json())
      alert('Läraren sparades korrekt!')
    }
    if (response.status >= 500 && response.status <= 599) {
      console.log(await response.json())
      alert('Internal server error!')
    }
    else {
      console.log(await response.json())
      alert('VARNING: Läraren sparades INTE korrekt!')
    }
  }

  return (
    <>
      <div className="page-section">
        <NavLink to='/teachers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Teachersidan</h4>
        </NavLink>
        <h2 className="page-title">Registrera en ny lärare i databasen</h2>
        <div className="page-content">
          <form className="form" onSubmit={handleSaveTeacher}>
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
            <div className="form-control">
              <label htmlFor="">Färdigheter, separera med komman:</label>
              <input onChange={onHandleSkillTextChange} value={skill} type="text" id='skill' name='skill' />
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

export default CreateTeacher