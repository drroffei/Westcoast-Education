import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import CourseListItem from "./CourseListItem";

function CourseList() {
  const [coursesList, setcoursesList] = useState([]);
  useEffect(() => { loadCourses() }, [])

  const loadCourses = async () => {
    const url = `${process.env.REACT_APP_BASEURL}/course`;
    const response = await fetch(url)

    if (!response.ok) {
      console.log('Hittade inga kurser');
    }
    else {
      console.log('Kurserna hittades')
    }
    setcoursesList(await response.json())
  }
  console.log(coursesList)

  return (
    <>
      <div className="page-section">
        <NavLink to='/courses'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Coursesidan</h4>
        </NavLink>
        <h2 className="page-title">Här kan du se och ändra kurser:</h2>
        <div className="page-content">
          <table>
            <thead>
              <tr>
                <td></td>
                <td>CourseNumber</td>
                <td>CourseName</td>
                <td>Duration</td>
                <td></td>
              </tr>
            </thead>
            <tbody>
              {coursesList.map((course) => (
                <CourseListItem course={course} key={course.id} />
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  )

}

export default CourseList