function CustomersMain() {
  return (
    <>
      <div className="page-section">
        <h2 className="page-title">Här kan du CRUD:a kunder</h2>
        <div className="page-content">
          <div className="page-item">
            <div className="page-item-title">
              <h4>C</h4><p>reate</p>
            </div>
            <p>Skapa en ny kund</p>
          </div>
          <div className="page-item">
            <div className="page-item-title">
              <h4>R</h4><p>ead</p>
            </div>
            <p>Hämta en lista med kunder</p>
          </div>
          <div className="page-item">
            <div className="page-item-title">
              <h4>U</h4><p>pdate</p>
            </div>
            <p>Ändra informationen på en kund</p>
          </div>
          <div className="page-item">
            <div className="page-item-title">
              <h4>D</h4><p>elete</p>
            </div>
            <p>Ta bort en kund ur systemet</p>
          </div>
        </div>
      </div>
    </>
  )
}
export default CustomersMain