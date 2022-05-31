import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import VehicleList from './Components/Vehicles/VehicleList';
import Home from './Components/home/Home';
import Navbar from './Components/navbar/Navbar';
import CustomersMain from './Components/Customers/CustomersMain';
import TeachersMain from './Components/Teachers/TeachersMain';
import CoursesMain from './Components/Courses/CoursesMain';

import './styles.css'

function App() {
  return (
    <Router>
      <Navbar />
      <main>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/Customers' element={<CustomersMain />} />
          <Route path='/Teachers' element={<TeachersMain />} />
          <Route path='/Courses' element={<CoursesMain />} />
        </Routes>
      </main>
    </Router>
  );
}
export default App;