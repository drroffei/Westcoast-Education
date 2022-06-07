import { useNavigate } from 'react-router-dom';

function CourseListItem(course) {
  const navigate = useNavigate();

  function onEditClickHandler() {
    navigate(`/courses/update/${course.course.courseNumber}`);
  }

  function onDeleteClickHandler() {
    navigate(`/courses/delete/${course.course.courseNumber}`);

  }

  return (
    <>
      <tr>
        <td><span onClick={onEditClickHandler}>
          <i className="fa-solid fa-pen-to-square"></i>
        </span></td>
        <td>{course.course.courseNumber}</td>
        <td>{course.course.courseName}</td>
        <td>{course.course.duration}</td>
        <td><span onClick={onDeleteClickHandler}>
          <i className="fa-solid fa-trash-can"></i>
        </span></td>
      </tr>
    </>
  )
}
export default CourseListItem