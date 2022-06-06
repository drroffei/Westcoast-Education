function TeachersReadItem(teacher) {
  console.log(teacher)

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
    </>
  )
}
export default TeachersReadItem