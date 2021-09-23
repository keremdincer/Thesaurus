import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { Button, Form, Input, InputGroup, InputGroupAddon } from 'reactstrap'

export const Home = () => {
  const [words, setWords] = useState([])
  const [search, setSearch] = useState('')

  useEffect(() => {
    fetch('api/words')
      .then((res) => res.json())
      .then((data) => setWords(data))
  }, [])

  function onSearch(e) {
    e.preventDefault()

    fetch(`/api/words/search/${search}`)
      .then((res) => res.json())
      .then((data) => setWords(data))
  }

  return (
    <div>
      <h1>Words:</h1>
      <hr />
      <Form onSubmit={onSearch}>
        <InputGroup>
          <Input onChange={(e) => setSearch(e.currentTarget.value)} />
          <InputGroupAddon addonType="prepend">
            <Button type="submit" color="primary" outline>
              Search
            </Button>
          </InputGroupAddon>
        </InputGroup>
      </Form>

      {words.length === 0 ? (
        <>
          <p>No words exists in thesaurus right now.</p>
          <Button tag={Link} color="success" to="/add">
            Add One
          </Button>
        </>
      ) : null}

      <br />

      {words.map((word) => (
        <Button
          style={{ margin: '4px' }}
          color="danger"
          tag={Link}
          to={`/words/${word.id}`}
          key={word.id}
        >
          {word.text}
        </Button>
      ))}
    </div>
  )
}
