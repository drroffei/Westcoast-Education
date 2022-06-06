import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { NavLink } from "react-router-dom";

function TeachersUpdateDetailedView() {
  const params = useParams();
  const [teacherId, setTeacherId] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [address, setAddress] = useState('');
  const [skills, setSkills] = useState('');

  useEffect(() => { LoadTeacher(params.id) }, [params.id])

  const LoadTeacher = async (id) => {
    const url = `${process.env.REACT_APP_BASEURL}/teachers/details/${id}`;
    const response = await fetch(url);

    if (!response.ok) {
      console.log('Hittade inga kunder');
    }
    else {
      console.log('Kunderna hittades')
    }

    const teacher = await response.json();
    console.log(teacher);
    setTeacherId(teacher.id);
    setFirstName(teacher.firstName);
    setLastName(teacher.lastName);
    setEmail(teacher.email);
    setPhoneNumber(teacher.phoneNumber);
    setAddress(teacher.address);
    let skillList = '';
    teacher.skills.map(({skillName}) => (
      skillList += `${skillName},`
    ));
    setSkills(skillList)
  }


  console.log(skills)

  const onHandleTeacherIdTextChange = (e) => {
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
  const onHandleSkillTextChange = (e) => {
    setSkills(e.target.value)
  }

  const handleSaveTeacher = (e) => {
    e.preventDefault();
    const teacher = {
      id: teacherId,
      firstName: firstName,
      lastName: lastName,
      email: email,
      phoneNumber: phoneNumber,
      address: address,
      teacherSkill: skills
    }
    saveTeacher(teacher)
    console.log(teacher)
  }

  const saveTeacher = async(teacher) => {
    const url = `${process.env.REACT_APP_BASEURL}/teachers/${teacherId}`
    const response = await fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(teacher),
    });

    if (response.status >= 200 && response.status <= 299) {
      console.log(await response.json());
      alert('Läraren sparades korrekt!');
    }
    else {
      console.log(await response.json());
      alert('VARNING: Läraren sparades INTE korrekt!');
    }
  }

  return (
    <>
      <div className="page-section">
        <NavLink to='/teachers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till lärarsidan</h4>
        </NavLink>
        <h2 className="page-title">Uppdatera en lärare i databasen</h2>
        <div className="page-content">
          <form className="form" onSubmit={handleSaveTeacher}>
            <div className="form-control">
              <input onChange={onHandleTeacherIdTextChange} value={teacherId} type="hidden" id='teacherId' name='teacherId' />
            </div>
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
              <label htmlFor="">Färdigheter, separera med komman: </label>
              <input onChange={onHandleSkillTextChange} value={skills} type="text" id='skill' name='skill' />              
            </div>

            <div className="button">
              <button type="submit" className="btn">Uppdatera</button>
            </div>
          </form>
        </div>
      </div>
    </>
  )

}
export default TeachersUpdateDetailedView