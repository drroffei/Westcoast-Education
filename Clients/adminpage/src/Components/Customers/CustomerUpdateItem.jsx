import { NavLink } from "react-router-dom"

function CustomerUpdateItem(customer) {
  return (
    <tr>
      <td>{customer.customer.firstName}</td>
      <td>{customer.customer.lastName}</td>
      <td><NavLink to="./"><i class="fa-solid fa-pen-to-square"></i></NavLink></td>
    </tr>
  )
}

export default CustomerUpdateItem