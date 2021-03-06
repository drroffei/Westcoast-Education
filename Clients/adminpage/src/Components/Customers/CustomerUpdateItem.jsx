import { useNavigate } from 'react-router-dom';

function CustomerUpdateItem(customer) {
  const navigate = useNavigate();

  function onEditClickHandler() {
    navigate(`/customers/update/${customer.customer.id}`);
  }

  return (
    <>
      <span value={customer.customer.id} hidden></span>
      <tr>
        <td>{customer.customer.firstName}</td>
        <td>{customer.customer.lastName}</td>
        <td>
          <span onClick={onEditClickHandler}>
            <i className="fa-solid fa-pen-to-square"></i>
          </span>
        </td>
      </tr>
    </>
  )
}

export default CustomerUpdateItem