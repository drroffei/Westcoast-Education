import { useNavigate } from 'react-router-dom';

function CustomerDeleteItem(customer) {
  const navigate = useNavigate();

  function onEditClickHandler() {
    navigate(`/customers/delete/${customer.customer.id}`);
  }

  return (
    <>
      <span value={customer.customer.id} hidden></span>
      <tr>
        <td>{customer.customer.firstName}</td>
        <td>{customer.customer.lastName}</td>
        <td>
          <span onClick={onEditClickHandler}>
            <i className="fa-solid fa-trash-can"></i>
          </span>
        </td>
      </tr>
    </>
  )
}

export default CustomerDeleteItem