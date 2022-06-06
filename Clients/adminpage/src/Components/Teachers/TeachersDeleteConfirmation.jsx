import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { NavLink } from "react-router-dom"

function CustomerDeleteConfirm() {
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
    teacher.skills.map(({ skillName }) => (
      skillList += `${skillName},`
    ));
    setSkills(skillList)
  }

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

  const onEditClickHandler = async () => {
    console.log(`Tar bort lärare med id ${params.id}`);
    const url = `${process.env.REACT_APP_BASEURL}/teachers/${params.id}`;
    const response = await fetch(url, {
      method: 'DELETE',
    });

    console.log(response);

    if (response.status >= 200 && response.status <= 299) {
      alert('Läraren togs bort från databasen')
    }
    else {
      alert('VARNING: Läraren togs INTE bort');
    }
  };

  return (
    <>
      <div className="page-section">
        <NavLink to='/teachers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Teachersidan</h4>
        </NavLink>
        <h2>Bekräfta borttagande av följande lärare:</h2>
        <div className="page-content">
          <div className="page-item">
            <form className="form">
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