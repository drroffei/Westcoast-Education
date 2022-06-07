import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

// import VehicleList from './Components/Vehicles/VehicleList';
import Home from './Components/home/Home';
import Navbar from './Components/navbar/Navbar';
import CustomersMain from './Components/Customers/CustomersMain';
import CustomerCreate from './Components/Customers/CustomerCreate';
import CustomerRead from './Components/Customers/CustomerRead';
import CustomerUpdate from './Components/Customers/CustomerUpdate';
import CustomerUpdateDetailedView from './Components/Customers/CustomerUpdateDetailedView';
import CustomerDelete from './Components/Customers/CustomerDelete';
import CustomerDeleteConfirm from './Components/Customers/CustomerDeleteConfirm';

import TeachersMain from './Components/Teachers/TeachersMain';
import TeacherCreate from './Components/Teachers/TeachersCreate';
import TeachersRead from './Components/Teachers/TeachersRead';
import TeachersUpdate from './Components/Teachers/TeachersUpdate';
import TeachersUpdateDetailedView from './Components/Teachers/TeachersUpdateDetailedView';
import TeachersDelete from './Components/Teachers/TeachersDelete';
import TeachersDeleteConfirmation from './Components/Teachers/TeachersDeleteConfirmation';

import CoursesMain from './Components/Courses/CoursesMain';
import CoursesCreate from './Components/Courses/CoursesCreate';
import CourseList from './Components/Courses/CourseList';
import CoursesUpdate from './Components/Courses/CoursesUpdate';
import CoursesDelete from './Components/Courses/CoursesDelete';

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
          <Route path='/customers/update/:id' element={<CustomerUpdateDetailedView />} />
          <Route path='/customers/delete' element={<CustomerDelete />} />
          <Route path='/customers/delete/:id' element={<CustomerDeleteConfirm />} />
          <Route path='/teachers' element={<TeachersMain />} />
          <Route path='/teachers/create' element={<TeacherCreate />} />
          <Route path='/teachers/read' element={<TeachersRead />} />
          <Route path='/teachers/update' element={<TeachersUpdate />} />
          <Route path='/teachers/update/:id' element={<TeachersUpdateDetailedView />} />
          <Route path='/teachers/delete' element={<TeachersDelete />} />
          <Route path='/teachers/delete/:id' element={<TeachersDeleteConfirmation />} />
          <Route path='/courses' element={<CoursesMain />} />
          <Route path='/courses/create' element={<CoursesCreate />} />
          <Route path='/courses/courselist' element={<CourseList />} />
          <Route path='/courses/update/:id' element={<CoursesUpdate />} />
          <Route path='/courses/delete/:id' element={<CoursesDelete />} />
        </Routes>
      </main>
    </Router>
  );
}
export default App;