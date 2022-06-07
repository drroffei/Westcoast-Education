function TeachersReadItem(teacher) {
  const skills = teacher.teacher.skills;
  console.log(skills);
  const searchword = teacher.searchword;
  console.log(searchword);
  let displayTeacher = false;

  skills.map((skill) => {
    if (skill.skillName.toLowerCase().includes(searchword) || searchword == "") {
      displayTeacher = true;
    }
    console.log(skill.skillName.includes(searchword))
  })

  if (displayTeacher) {
    return (
      <div className="teacher-item">

        <span hidden value={teacher.teacher.id}></span>
        <h3>{teacher.teacher.firstName}, {teacher.teacher.lastName}</h3>
        <div>
          <p className='skills-title'>Färdigheter: </p>
          {teacher.teacher.skills.map((skill) => (
            <p>{skill.skillName}</p>
          ))}
        </div>
      </div>
    )
  }
  else {
    return (
      <div></div>
    )
  }


}
export default TeachersReadItem