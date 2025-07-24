(ns pangram
  (:require [clojure.string :as str]))

(defn all-letters-in [sentence]
  (str/lower-case (str/replace sentence #"\s|_|\"|[1-9]|\." ""))
  )

(defn pangram? [sentence]
  (= (set (all-letters-in sentence)) (set "abcdefghijklmnopqrstuvwxyz"))
)
