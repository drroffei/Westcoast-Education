function VehicleItem(props) {
  return (
    <tr>
      <td>{props.regNumber}</td>
      <td>{props.make}</td>
      <td>{props.model}</td>
      <td>{props.modelYear}</td>
    </tr>
  );
}
export default VehicleItem;