import { NavLink } from "react-router-dom"

function CustomersMain() {
  return (
    <>
      <div className="page-section">
        <h2 className="page-title">Här kan du CRUD:a kunder</h2>
        <div className="page-content">
          <div className="page-item">
            <NavLink to="/customers/create">
              <div className="page-item-title">
                <h4>C</h4><p>reate</p>
              </div>
              <p>Skapa en ny kund</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/customers/read">
              <div className="page-item-title">
                <h4>R</h4><p>ead</p>
              </div>
              <p>Hämta en lista med kunder</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/customers/update">
              <div className="page-item-title">
                <h4>U</h4><p>pdate</p>
              </div>
              <p>Ändra informationen på en kund</p>
            </NavLink>
          </div>
          <div className="page-item">
            <NavLink to="/customers/delete">
              <div className="page-item-title">
                <h4>D</h4><p>elete</p>
              </div>
              <p>Ta bort en kund ur systemet</p>
            </NavLink>
          </div>
        </div>
      </div>
    </>
  )
}
export default CustomersMain