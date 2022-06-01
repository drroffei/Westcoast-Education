import { NavLink } from 'react-router-dom'

function Navbar() {
  return (
    <nav className="navbar">
      <h1 className="nav-logo "><NavLink to="/">Westcoast Education</NavLink></h1>
      <div className="">
        <ul className="navbar-list">
          <li className="navbar-item">
            <NavLink to="/customers">Customers</NavLink>
          </li>
          <li className="navbar-item">
            <NavLink to="/teachers">Teachers</NavLink>
          </li>
          <li className="navbar-item">
            <NavLink to="/courses">Courses</NavLink>
          </li>
        </ul>
      </div>
    </nav>
  )
}

export default Navbar