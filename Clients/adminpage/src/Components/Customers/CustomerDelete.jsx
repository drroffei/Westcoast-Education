import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom"
import CustomerDeleteItem from './CustomerDeleteItem'

function Delete() {
  const [customersList, setCustomersList] = useState([]);
  useEffect(() => { loadCustomers() }, [])

  const loadCustomers = async () => {
    const url = `${process.env.REACT_APP_BASEURL}/customers`;
    const response = await fetch(url)

    if (!response.ok) {
      console.log('Hittade inga kunder');
    }
    else {
      console.log('Kunderna hittades')
    }
    setCustomersList(await response.json())
  }
  console.log(customersList)



  return (
    <>
      <div className="page-section">
        <NavLink to='/customers'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till Customersidan</h4>
        </NavLink>
        <h2>Här kan du ta bort kunder från databasen</h2>
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
                {customersList.map((customer) => (
                  <CustomerDeleteItem
                    customer={customer}
                    key={customer.id} />
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </>
  )
}
export default Delete