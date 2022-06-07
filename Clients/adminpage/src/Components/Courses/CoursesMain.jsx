import { NavLink } from "react-router-dom"

function CoursesMain() {
  return (
    <>
      <div className="page-section">
        <h2 className="page-title">Här kan du administrera kurser</h2>
        <div className="page-content">
          <div className="page-item">
            <NavLink to="/courses/create">
              <div className="page-item-title">
                <h4>S</h4><p>kapa en ny kurs</p>
              </div>
              <p>Skapa en ny kurs i databasen</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/courses/courselist">
              <div className="page-item-title">
                <h4>A</h4><p>lla kurser</p>
              </div>
              <p>Se informaton om alla kurser</p>
            </NavLink>
          </div>
        </div>
      </div>
    </>
  )
}
export default CoursesMain