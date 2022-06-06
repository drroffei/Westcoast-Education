import { NavLink } from "react-router-dom"

function TeachersMain() {
  return (
    <>
      <div className="page-section">
        <h2 className="page-title">Här kan du CRUD:a lärare</h2>
        <div className="page-content">
        <div className="page-item">
            <NavLink to="/teachers/create">
              <div className="page-item-title">
                <h4>C</h4><p>reate</p>
              </div>
              <p>Skapa en ny lärare</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/teachers/read">
              <div className="page-item-title">
                <h4>R</h4><p>ead</p>
              </div>
              <p>Hämta en lista med lärare</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/teachers/update">
              <div className="page-item-title">
                <h4>U</h4><p>pdate</p>
              </div>
              <p>Ändra informationen på en lärare</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/teachers/delete">
              <div className="page-item-title">
                <h4>D</h4><p>elete</p>
              </div>
              <p>Ta bort en lärare ur systemet</p>
            </NavLink>
          </div>
        </div>
      </div>
    </>
  )
}
export default TeachersMain