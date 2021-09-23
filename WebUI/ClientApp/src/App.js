import React, { Component } from 'react'
import { Route } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './components/Home'

import './custom.css'
import { Word } from './components/Word'
import { AddWord } from './components/AddWord'

export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/words/:id" component={Word} />
        <Route exact path="/add" component={AddWord} />
      </Layout>
    )
  }
}
