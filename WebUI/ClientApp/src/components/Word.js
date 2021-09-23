import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { Link } from 'react-router-dom'
import { Button } from 'reactstrap'

export const Word = () => {
  const { id } = useParams()
  const [word, setWord] = useState(null)

  useEffect(() => {
    fetch(`api/words/${id}`)
      .then((res) => res.json())
      .then((data) => setWord(data))
  }, [id])

  if (!word) {
    return <div></div>
  }

  return (
    <div>
      <h1>{word.text}</h1>
      <hr />
      <h2>Synonyms:</h2>
      {word.synonyms.map(({ toWord }) => (
        <Button
          style={{ margin: '4px' }}
          color="danger"
          tag={Link}
          to={`/words/${toWord.id}`}
        >
          {toWord.text}
        </Button>
      ))}
    </div>
  )
}
