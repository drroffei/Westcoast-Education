
function CustomerReadItem(customer){
  console.log(customer)
  return(
      <tr>
        <td>{customer.customer.firstName}</td>
        <td>{customer.customer.lastName}</td>
        <td>{customer.customer.email}</td>
        <td>{customer.customer.phoneNumber}</td>
        <td>{customer.customer.address}</td>
      </tr>
  )
}
export default CustomerReadItem