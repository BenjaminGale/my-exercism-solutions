(ns pangram
  (:require [clojure.string :as str]))

(def all-letters (set "abcdefghijklmnopqrstuvwxyz"))

(defn all-letters-in [sentence]
  (set (str/lower-case (str/replace sentence #"\s|_|\"|[1-9]|\." "")))
  )

(defn pangram? [sentence]
  (= (all-letters-in sentence) all-letters)
)
