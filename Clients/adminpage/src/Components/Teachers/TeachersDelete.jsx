import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom"
import TeachersDeleteItem from './TeachersDeleteItem'


function TeachersDelete() {
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
        <h2>Här kan du ta bort kunder från lärare</h2>
        <div className="page-content">
          <div className="page-item">
            <table>
              <thead>
                <tr>
                  <th>Förnamn</th>
                  <th>Efternamn</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {teachersList.map((teacher) => (
                  <TeachersDeleteItem
                    teacher={teacher}
                    key={teacher.id} />
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </>
  )
}
export default TeachersDelete