(ns pangram
  (:require [clojure.string :as str]))

(def all-letters (set "abcdefghijklmnopqrstuvwxyz"))

(defn all-letters-in [sentence]
  (str/lower-case (str/replace sentence #"\s|_|\"|[1-9]|\." ""))
  )

(defn pangram? [sentence]
  (= (set (all-letters-in sentence)) all-letters)
)
