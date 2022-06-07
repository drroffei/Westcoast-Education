import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom"
import TeacherReadItem from "./TeachersReadItem"

function TeachersRead() {
  const [teachersList, setTeachersList] = useState([]);
  const [searchword, setSearchWord] = useState([]);
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

  const onHandleSearchBoxChange = (e) => {
    setSearchWord(e.target.value)
  }
  console.log(teachersList)
  console.log(searchword)

  return (
    <>
      <div className="page-section">
        <NavLink to='/teachers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Teachersidan</h4>
        </NavLink>
        <h2 className="page-title">Här kan du se alla lärare:</h2>
        <div className="form-control">
          <label htmlFor="">Sök på färdigheter</label>
          <input onChange={onHandleSearchBoxChange} value={searchword} type="text" id='searchword' name='searchword' />
        </div>
        <div className="teacher-list">
          {teachersList.map((teacher) => (
            <TeacherReadItem
              teacher={teacher}
              key={teacher.id}
              searchword={searchword} />
              ))}
              
        </div>
      </div>
    </>
  )
}
export default TeachersRead