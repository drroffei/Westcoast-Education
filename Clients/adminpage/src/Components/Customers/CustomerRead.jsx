import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom"
import CustomerReadItem from './CustomerReadItem'

function Read() {
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
        <h2 className="page-title">Här kan du se alla kunder:</h2>
        <div className="page-content">
          <table>
            <thead>
              <tr>
                <th>Förnamn</th>
                <th>Efternamn</th>
                <th>Epost</th>
                <th>Telefonnummer</th>
                <th>Adress</th>
              </tr>
            </thead>
            <tbody>
              {customersList.map((customer) => (
                <CustomerReadItem
                  customer={customer}
                  key={customer.id} />
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  )
}
export default Read