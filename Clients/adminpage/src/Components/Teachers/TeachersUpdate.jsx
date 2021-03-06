import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom"
import TeachersUpdateItem from "./TeachersUpdateItem"

function TeachersUpdate() {
  const [teachersList, setTeachersList] = useState([]);
  useEffect(() => { loadTeachers() }, [])

  const loadTeachers = async () => {
    const url = `${process.env.REACT_APP_BASEURL}/teachers`;
    const response = await fetch(url)

    if (!response.ok) {
      console.log('Hittade inga lärare');
    }
    else {
      console.log('Lärarna hittades')
    }
    setTeachersList(await response.json())
  }
  console.log(teachersList)

  

  return (
    <>
      <div className="page-section">
        <NavLink to='/teachers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Teachersidan</h4>
        </NavLink>
        <h2 className="page-title">Här kan du uppdatera information om en lärare:</h2>
        <div className="teacher-list">
          {teachersList.map((teacher) => (
            <div className="teacher-item">
              <TeachersUpdateItem
                teacher={teacher}
                key={teacher.id} />
            </div>
          ))}
        </div>
      </div>
    </>
  )
}
export default TeachersUpdate 