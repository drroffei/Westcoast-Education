import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import VehicleList from './Components/Vehicles/VehicleList';
import Home from './Components/home/Home';
import Navbar from './Components/navbar/Navbar';
import CustomersMain from './Components/Customers/CustomersMain';
import CustomerCreate from './Components/Customers/CustomerCreate'
import CustomerRead from './Components/Customers/CustomerRead'
import CustomerUpdate from './Components/Customers/CustomerUpdate'
import CustomerDelete from './Components/Customers/CustomerDelete'

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
          <Route path='/customers' element={<CustomersMain />} />
          <Route path='/customers/create' element={<CustomerCreate />} />
          <Route path='/customers/read' element={<CustomerRead />} />
          <Route path='/customers/update' element={<CustomerUpdate />} />
          <Route path='/customers/delete' element={<CustomerDelete />} />
          <Route path='/teachers' element={<TeachersMain />} />
          <Route path='/teachers/create' element={<TeachersMain />} />
          <Route path='/teachers/read' element={<TeachersMain />} />
          <Route path='/teachers/update' element={<TeachersMain />} />
          <Route path='/teachers/delete' element={<TeachersMain />} />
          <Route path='/courses' element={<CoursesMain />} />
          <Route path='/courses/create' element={<CoursesMain />} />
          <Route path='/courses/read' element={<CoursesMain />} />
          <Route path='/courses/update' element={<CoursesMain />} />
          <Route path='/courses/delete' element={<CoursesMain />} />
        </Routes>
      </main>
    </Router>
  );
}
export default App;