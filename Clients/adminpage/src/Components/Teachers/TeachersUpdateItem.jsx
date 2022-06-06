import { useNavigate } from 'react-router-dom';

function TeachersUpdateItem(teacher) {
  const navigate = useNavigate();
  console.log(teacher)

  function onEditClickHandler() {
    navigate(`/teachers/update/${teacher.teacher.id}`);
  }

  return (
    <>
      <span hidden value={teacher.teacher.id}></span>
      <h3>{teacher.teacher.firstName}, {teacher.teacher.lastName}</h3>
      <div>
        <p className='skills-title'>Färdigheter: </p>
        {teacher.teacher.skills.map((skill) => (
          <p>{skill.skillName}</p>
        ))}
      </div>
      <span onClick={onEditClickHandler}>
        <i className="fa-solid fa-pen-to-square"></i>
      </span>
    </>
  )
}
export default TeachersUpdateItem