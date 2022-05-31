import VehicleItem from "./VehicleItem";

function VehicleList(){
  return(
      <table>
        <thead>
          <tr>
            <th>Regnummer</th>
            <th>Tillverkare</th>
            <th>Modell</th>
            <th>Modellår</th>
          </tr>
        </thead>
        <tbody>
          <VehicleItem regNumber="BBB222" make="Volvo" model="V60" modelYear="2019"/>
          <VehicleItem regNumber="AAA333" make="Ford" model="Mustang" modelYear="2009"/>
        </tbody>
      </table>
  )
}
export default VehicleList