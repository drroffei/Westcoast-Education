import { useNavigate } from 'react-router-dom';

function TeachersDeleteItem(teacher) {
  const navigate = useNavigate();

  function onEditClickHandler() {
    navigate(`/teachers/delete/${teacher.teacher.id}`);
  }

  return (
    <>
      <span value={teacher.teacher.id} hidden></span>
      <tr>
        <td>{teacher.teacher.firstName}</td>
        <td>{teacher.teacher.lastName}</td>
        <td>
          <span onClick={onEditClickHandler}>
            <i className="fa-solid fa-trash-can"></i>
          </span>
        </td>
      </tr>
    </>
  )
}

export default TeachersDeleteItem