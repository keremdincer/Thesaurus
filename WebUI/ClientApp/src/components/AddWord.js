import React, { useState } from 'react'
import { useHistory } from 'react-router'
import { Button, Form, FormGroup, Input, Label } from 'reactstrap'

export const AddWord = () => {
  const [word, setWord] = useState('')
  const [synonyms, setSynonyms] = useState('')
  const history = useHistory()

  function onSubmit(e) {
    e.preventDefault()

    fetch('/api/words', {
      method: 'POST',
      body: JSON.stringify({
        Word: word,
        Synonyms: synonyms.split(',').map((s) => s.trim()),
      }),
      headers: {
        'Content-Type': 'application/json',
      },
    }).then(() => history.push('/'))
  }

  return (
    <Form onSubmit={onSubmit}>
      <FormGroup>
        <Label for="word">Word</Label>
        <Input
          type="text"
          name="word"
          id="word"
          placeholder="ie. fast"
          onChange={(e) => setWord(e.currentTarget.value)}
        />
      </FormGroup>

      <FormGroup>
        <Label for="synonyms">
          Synonyms (Separated with commas ie: "rapid, quick")
        </Label>
        <Input
          type="text"
          name="synonyms"
          id="synonyms"
          onChange={(e) => setSynonyms(e.currentTarget.value)}
        />
      </FormGroup>

      <Button color="info">Submit</Button>
    </Form>
  )
}
