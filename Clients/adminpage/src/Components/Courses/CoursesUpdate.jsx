import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { NavLink } from "react-router-dom"

function CoursesUpdate() {
  const params = useParams();
  const [courseId, setCourseId] = useState('');
  const [courseNumber, setCourseNumber] = useState('');
  const [courseName, setCourseName] = useState('');
  const [duration, setDuration] = useState('');
  const [category, setCategory] = useState('');
  const [description, setDescription] = useState('');
  const [details, setDetails] = useState('');
  const [teacherId, setTeacherId] = useState('');

  const onHandleCourseIdTextChange = (e) => {
    setCourseId(e.target.value)
  }
  const onHandleCourseNumberTextChange = (e) => {
    setCourseNumber(e.target.value)
  }
  const onHandleCourseNameTextChange = (e) => {
    setCourseName(e.target.value)
  }
  const onHandleDurationTextChange = (e) => {
    setDuration(e.target.value)
  }
  const onHandleCategoryTextChange = (e) => {
    setCategory(e.target.value)
  }
  const onHandleDescriptionTextChange = (e) => {
    setDescription(e.target.value)
  }
  const onHandleDetailsTextChange = (e) => {
    setDetails(e.target.value)
  }
  const onHandleTeacherIdTextChange = (e) => {
    setTeacherId(e.target.value)
  }

  useEffect(() => { LoadCourse(params.id) }, [params.id])

  const LoadCourse = async (id) => {
    const url = `${process.env.REACT_APP_BASEURL}/course/bycoursenumber/${id}`;
    const response = await fetch(url);

    if (!response.ok) {
      console.log('Hittade ingen kurs');
    }
    else {
      console.log('Kursen hittades')
    }

    const course = await response.json();
    console.log(course);
    setCourseId(course.courseId);
    setCourseNumber(course.courseNumber);
    setCourseName(course.courseName);
    setDuration(course.duration);
    setCategory(course.category);
    setDescription(course.description);
    setDetails(course.details);
    setTeacherId(course.teacherId);
  }

  const handleSaveCourse = (e) => {
    e.preventDefault();
    const course = {
      id: courseId,
      courseNumber: courseNumber,
      courseName: courseName,
      duration: duration,
      category: category,
      description: description,
      details: details,
      teacherId: teacherId
    }
    console.log(course)
    saveCourse(course)
  }

  const saveCourse = async (course) => {
    const url = `${process.env.REACT_APP_BASEURL}/course/${courseId}`
    const response = await fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(course),
    });

    if (response.status >= 200 && response.status <= 299) {
      console.log(await response.json());
      alert('Kursen sparades korrekt!');
    }
    else {
      console.log(await response.json());
      alert('VARNING: Kursen sparades INTE korrekt!');
    }
  }

  return (
    <>
      <div className="page-section">
        <NavLink to='/courses/courselist'>
          <h4><i className="fa-solid fa-arrow-left"></i>Tillbaka till kurslistan</h4>
        </NavLink>
        <h3>Här kan du uppdatera informationen på kursen:</h3>
        <div className="page-content">
          <form className="form" onSubmit={handleSaveCourse}>
            <div className="form-control">
              <input onChange={onHandleCourseIdTextChange} value={courseId} type="hidden" id='courseId' name='courseId' />
            </div>
            <div className="form-control">
              <label htmlFor="">Kursnummer </label>
              <input onChange={onHandleCourseNumberTextChange} value={courseNumber} type="text" id='courseNumber' name='courseNumber' />
            </div>
            <div className="form-control">
              <label htmlFor="">Kursnamn </label>
              <input onChange={onHandleCourseNameTextChange} value={courseName} type="text" id='courseName' name='courseName' />
            </div>
            <div className="form-control">
              <label htmlFor="">Varaktighet </label>
              <input onChange={onHandleDurationTextChange} value={duration} type="text" id='duration' name='duration' />
            </div>
            <div className="form-control">
              <label htmlFor="">Kategori </label>
              <input onChange={onHandleCategoryTextChange} value={category} type="text" id='category' name='category' />
            </div>
            <div className="form-control">
              <label htmlFor="">Beskrivning </label>
              <input onChange={onHandleDescriptionTextChange} value={description} type="text" id='description' name='description' />
            </div>
            <div className="form-control">
              <label htmlFor="">Detaljer </label>
              <input onChange={onHandleDetailsTextChange} value={details} type="text" id='details' name='details' />
            </div>
            <div className="form-control">
              <label htmlFor="">LärarId </label>
              <input onChange={onHandleTeacherIdTextChange} value={teacherId} type="text" id='teacherId' name='teacherId' />
            </div>
            <div className="button">
              <button type="submit" className="btn">Uppdatera</button>
            </div>
          </form>
        </div>
      </div>
    </>
  )
}
export default CoursesUpdate